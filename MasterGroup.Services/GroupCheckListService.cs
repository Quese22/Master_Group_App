using MasterGroup.Data;
using MasterGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Services
{
    public class GroupCheckListService
    {
        private readonly Guid _userId;

        public GroupCheckListService(Guid userid)
        {
            _userId = userid;
        }

        public IEnumerable<GroupCheckListItem> GetCheckLists(int groupId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MGLists
                    .Where(e => e.ListId == groupId)
                    .Select(
                    e =>
                    new GroupCheckListItem
                    {
                        ListId=e.ListId,
                        Check1 = e.Check1,
                        Check2 = e.Check2,
                        Check3 = e.Check3,
                        ModifiedUtc= e.ModifiedUtc,
                        GroupId=groupId
                    }
                    );
                return query.ToArray();
            }
        }
        public bool CreateCheckList(GroupCheckListCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new MasterGroup.Data.GroupCheckLists()
                {
                    ListId = model.ListId,
                    Check1 = model.Check1,
                    Check2 = model.Check2,
                    Check3 = model.Check3,
                    ModifiedUtc = DateTimeOffset.Now
                };
                ctx.MGLists.Add(entity);
                ctx.SaveChanges();

                return ctx.SaveChanges() == 1;
            }   
        }

        public CheckListDetail GetCheckListById(int groupid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MGLists
                    .Single(e => e.ListId == groupid);
                return
                new CheckListDetail
                {
                    
                    ListId = entity.ListId,
                    Check1 = entity.Check1,
                    Check2 = entity.Check2,
                    Check3 = entity.Check3,
                    ModifiedUtc=entity.ModifiedUtc
              
                };
            }
        }

        public bool UpdateCheckList(CheckListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MGLists
                    .Single(e => e.ListId == model.ListId);
                entity.Check1 = model.Check1;
                entity.Check2 = model.Check2;
                entity.Check3 = model.Check3;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

    }
    
}
