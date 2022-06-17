using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DataAccessLayer.EntityFramework
{
    public class EfActivityRepository : GenericRepository<Activity>, IActivityDal
    {
        Context c = new Context();

        public void ChangeActivityConfirmation(long activityId, bool isConfirmed, long confirmedBy, DateTime confirmedTime)
        {
            var a = c.Activity.Find(activityId);
            a.IsConfirmed = isConfirmed;
            a.ConfirmedBy = confirmedBy;
            a.ConfirmedTime = confirmedTime;
            c.SaveChanges();
        }
        public bool CheckEmptyKontenjan(long activityId)
        {
            var activityInvites = (from ai in c.ActivityInvite
                                   join a in c.Activity
                                   on ai.ActivityId equals a.ID
                                   where ai.ActivityId == activityId
                                   select new ActivityInvite
                                   {
                                       AIActivity = a
                                   }).ToList();
            if (activityInvites.Count() == 0 || activityInvites.Count() < activityInvites.First().AIActivity.MaksKontenjan)
            {
                return true;
            }
            return false;
        }

        public void DeleteActivityById(long activityId, long deletedBy, DateTime deletedTime)
        {
            var a = c.Activity.Find(activityId);
            a.IsDeleted = true;
            a.DeletedBy = deletedBy;
            a.DeletedTime = deletedTime;
            c.SaveChanges();
        }

        public IList<Activity> GetConfirmedList()
        {
            return c.Activity.Where(a => a.IsConfirmed == true && a.IsDeleted == false).ToList();
        }

        public IList<ActivityViewModel> GetListOrderByCreatedTime()
        {
            var activityVM = (from a in c.Activity
                              .Include(a => a.CreatedUser)
                              .Include(a => a.UpdatedUser)
                              .Include(a => a.ConfirmedUser)
                              where a.IsDeleted == false
                              select new ActivityViewModel
                              {
                                  Activity = a,
                                  ActivityID = a.ID
                              }).OrderByDescending(a => a.Activity.CreatedTime).ToList();
            return activityVM;
        }
        public IList<ActivityViewModel> GetListOrderByCreatedTimeAndByUserId(long userId)
        {
            var activityVM = (from ai in c.ActivityInvite
                              .Include(a => a.InvitedUser)
                              .Include(a => a.AIActivity)
                              .Include(a => a.AICreatedUser)
                              where ai.IsDeleted == false && ai.IsConfirmed == true && ai.InvitedUserId == userId
                              select new ActivityViewModel
                              {
                                  ActivityInvite = ai,
                                  ActivityID = ai.AIActivity.ID,
                                  Activity = ai.AIActivity
                              }).OrderByDescending(a => a.Activity.CreatedTime).ToList();
            return activityVM;
        }
    }
}
