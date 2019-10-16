using MasterGroup.Data;
using MasterGroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterGroup.Services
{
    public class MasterGroupService
    {
        private readonly Guid _userID;
        public MasterGroupService(Guid userId)
        {
            _userID = userId;
        }

        public bool CreateMasterGroup(MasterGroupCreate model)
        {
            var entity = new MasterGroup.Data.MasterGroup()
            {
                OwnerId = _userID,
                Subject = model.Subject,
                Name = model.Name,
                Description = model.Description,
                CheckItem1 = model.CheckItem1,
                CheckItem2 = model.CheckItem2,
                CheckItem3 = model.CheckItem3,
                CreatedUtc = DateTimeOffset.Now,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MGroups.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MasterGroupItem> GetMasterGroup()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Single(e => e.Id == _userID.ToString());

                var query =
                    ctx
                        .MGroups
                        .Where(e => e.OwnerId == _userID)
                        .Select(
                            e =>
                                new MasterGroupItem
                                {
                                    OwnerID = e.OwnerId,
                                    Username = user.UserName,
                                    GroupID = e.GroupId,
                                    Subject = e.Subject,
                                    Name = e.Name,
                                    Description = e.Description,
                                    CreatedUtc = e.CreatedUtc,
                                }
                        ).ToList();
                

                return query;
            }
        }

        public MasterGroupDetails GetMasterGroupById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MGroups
                    .Single(e => e.GroupId == id && e.OwnerId == _userID);

                return
                    new MasterGroupDetails
                    {
                        GroupId = entity.GroupId,
                        Subject = entity.Subject,
                        Name = entity.Name,
                        Description = entity.Description,
                        CheckItem1 = entity.CheckItem1,
                        CheckItem2 = entity.CheckItem2,
                        CheckItem3 = entity.CheckItem3,
                    };
            }
        }
    }
}
    


