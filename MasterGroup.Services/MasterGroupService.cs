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

        public bool CreateMasterGroup(MasterGroupCreate model, string username)
        {
            //var user = ctx.Users.Single(e => e.Id == _userID.ToString());
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new MasterGroup.Data.MasterGroup()
                {
                    OwnerId = _userID,
                    Subject = model.Subject,
                    Username = username,
                    Name = model.Name,
                    Description = model.Description,
                    CheckItem1 = model.Commitment1,
                    CheckItem2 = model.Commitment2,
                    CheckItem3 = model.Commitment3,
                    CreatedUtc = DateTimeOffset.Now
                };
                ctx.MGroups.Add(entity);
                ctx.SaveChanges();
                entity.ListId = entity.GroupId;
                entity.Quese = new GroupCheckLists
                {
                    Check1 = model.Check1,
                    Check2 = model.Check2,
                    Check3 = model.Check3
                };
                return ctx.SaveChanges() == 2;

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
                                    Username = e.Username,
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
        //hey we are in the service layer which is right before the database layer. we are going to create a method that is going to allow us to show a single master group item. so first we open the window with the using statemtnet allowing us to quickly reach into our database for a single user in the database. we then convert that persons user ID back into a string as when we pull it out it goes back into a guid form. after we have done that we make a variable of query that is helping us look for a single database item (master group) in our listes of master groups which is made known by the fact its in MGroups (our database of master GROUPS
        public IEnumerable<MasterGroupItem> GetMasterGroupForAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Single(e => e.Id == _userID.ToString());
                var query =
                    ctx
                        .MGroups
                        .Select(
                            e =>
                                new MasterGroupItem
                                {
                                    OwnerID = _userID,
                                    Username = e.Username,
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
            using (var ctx = new ApplicationDbContext())
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
        public bool UpdateMasterGroup(MasterGroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MGroups
                        .Single(e => e.GroupId == model.GroupId && e.OwnerId == _userID);

                entity.GroupId = model.GroupId;
                entity.Subject = model.Subject;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.CheckItem1 = model.CheckItem1;
                entity.CheckItem2 = model.CheckItem2;
                entity.CheckItem3 = model.CheckItem3;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMasterGroup(int groupId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MGroups
                        .Single(e => e.GroupId == groupId && e.OwnerId == _userID);
                ctx.MGroups.Remove(entity);
                var entity2 =
                    ctx
                    .MGLists
                    .Single(e => e.ListId == groupId && e.ListId == groupId);
                ctx.MGLists.Remove(entity2);

                return ctx.SaveChanges() == 2;
            }
        }
    }
}



