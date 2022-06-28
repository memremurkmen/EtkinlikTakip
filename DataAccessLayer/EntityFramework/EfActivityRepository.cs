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
                                   where ai.ActivityId == activityId && ai.IsDeleted == false
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
        public bool CheckActivityLocationConflict(Activity activity)
        {
            IList<Activity> activities = c.Activity.Where(a => a.Lokasyon == activity.Lokasyon && a.IsDeleted == false && a.ID != activity.ID).Select(a => new Activity
            {
                Start = a.Start,
                End = a.End,
                IsAllDay = a.IsAllDay
            }).ToList();
            bool locationConflict = false;
            foreach (Activity actvty in activities)
            {
                if (actvty.IsAllDay && activity.IsAllDay)
                {
                    if (DateTime.Compare(actvty.Start, activity.Start) == 0)
                    {
                        locationConflict = true;
                        break;
                    }
                }
                else if ((DateTime.Compare(actvty.Start, activity.Start) == -1 && DateTime.Compare(actvty.End, activity.Start) == 1) ||
                    (DateTime.Compare(actvty.Start, activity.End) == -1 && DateTime.Compare(actvty.End, activity.End) == 1))
                {
                    locationConflict = true;
                    break;
                }
            }

            return locationConflict;
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
        public IList<ActivityViewModel> GetListOrderByDeletedTime()
        {
            var activityVM = (from a in c.Activity
                              .Include(a => a.CreatedUser)
                              .Include(a => a.UpdatedUser)
                              .Include(a => a.ConfirmedUser)
                              where a.IsDeleted == true
                              select new ActivityViewModel
                              {
                                  Activity = a,
                                  ActivityID = a.ID
                              }).OrderByDescending(a => a.Activity.DeletedTime).ToList();
            return activityVM;
        }
        public IList<ActivityViewModel> GetListOrderByCreatedTimeAndByUserId(long userId)
        {
            var activityVM = (from a in c.Activity
                              .Include(a => a.CreatedUser)
                              .Include(a => a.UpdatedUser)
                              .Include(a => a.ConfirmedUser)
                              join ai in c.ActivityInvite
                              on a.ID equals ai.ActivityId
                              where a.IsDeleted == false && ai.InvitedUserId == userId
                              select new ActivityViewModel
                              {
                                  ActivityID = a.ID,
                                  Activity = a
                              }).OrderByDescending(a => a.Activity.CreatedTime).ToList();
            return activityVM;
        }
    }
}
