using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfActivityInviteRepository : GenericRepository<ActivityInvite>, IActivityInviteDal
    {
        Context c = new Context();

        public ActivityInvite CheckActivityInvite(long activityId, long invitedUserId)
        {
            var invite = (from ai in c.ActivityInvite
                          join a in c.Activity
                          on ai.ActivityId equals a.ID
                          join u in c.User
                          on ai.InvitedUserId equals u.Id
                          where ai.ActivityId == activityId && ai.InvitedUserId == invitedUserId
                          select new ActivityInvite
                          {
                              InvitedUser = u,
                              AIActivity = a,
                              Id = ai.Id,
                              IsConfirmed = ai.IsConfirmed
                          }).FirstOrDefault();
            return invite;
        }

        public void DeleteActivityInviteById(Guid activityInviteId, long deletedBy, DateTime deletedTime)
        {
            var ai = c.ActivityInvite.Find(activityInviteId);
            ai.IsDeleted = true;
            ai.DeletedBy = deletedBy;
            ai.DeletedTime = deletedTime;
            c.SaveChanges();
        }
        public void ChangeInviteConfirmation(Guid activityInviteId, bool isConfirmed, long confirmedBy, DateTime confirmedTime)
        {
            var ai = c.ActivityInvite.Find(activityInviteId);
            ai.IsConfirmed = isConfirmed;
            ai.ConfirmedBy = confirmedBy;
            ai.ConfirmedTime = confirmedTime;
            c.SaveChanges();
        }

        public IList<ActivityInvite> GetInvitees(long activityId)
        {
            var activity = (from ai in c.ActivityInvite
                            .Include(a => a.InvitedUser)
                            .Include(a => a.AICreatedUser)
                            .Include(a => a.AIConfirmedUser)
                            join a in c.Activity
                            on ai.ActivityId equals a.ID
                            where ai.ActivityId == activityId && ai.IsDeleted == false
                            select new ActivityInvite
                            {
                                Id = ai.Id,
                                InvitedUser = ai.InvitedUser,
                                AICreatedUser = ai.AICreatedUser,
                                AIConfirmedUser = ai.AIConfirmedUser,
                                IsConfirmed = ai.IsConfirmed,
                                AIActivity = a
                            }).ToList();
            return activity;
        }
        
        public IList<ActivityInvite> GetInvitees(long activityId, bool isConfirmed)
        {
            var activity = (from ai in c.ActivityInvite
                            .Include(a => a.InvitedUser)
                            .Include(a => a.AICreatedUser)
                            .Include(a => a.AIConfirmedUser)
                            join a in c.Activity
                            on ai.ActivityId equals a.ID
                            where ai.ActivityId == activityId && ai.IsDeleted == false && ai.IsConfirmed == isConfirmed
                            select new ActivityInvite
                            {
                                Id = ai.Id,
                                InvitedUser = ai.InvitedUser,
                                AICreatedUser = ai.AICreatedUser,
                                AIConfirmedUser = ai.AIConfirmedUser,
                                IsConfirmed = ai.IsConfirmed,
                                AIActivity = a
                            }).ToList();
            return activity;
        }

    }
}
