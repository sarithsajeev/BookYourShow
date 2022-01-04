using BookYourShow.Models;
using BookYourShow.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using BookYourShow.Api.Controllers;


namespace BookYourShow.Api.Test.MockData
{
    public class CrewMockData
    {
        public async static Task<List<Crew>> GetMembers_Mock()
        {
            var _members = new List<Crew>()
            {
                new Crew()
                {
                    MemberId=4,
                    MemberName="Basil Joseph",
                    IsActive=true
                },
                new Crew()
                {
                    MemberId=5,
                    MemberName="Girish Gangadharan",
                    IsActive=true
                }
            };
            return _members;
        }

        public static Mock<ICrewRepo> AddMembers_Mock()
        {
            var members = new List<Crew>()
            {
                new Crew()
                {
                    MemberId=3,
                    MemberName="Rajesh",
                    IsActive = true
                },
                new Crew()
                {
                    MemberId = 9,
                    MemberName="Shirley",
                    IsActive = true
                }
            };


            var mockRepo = new Mock<ICrewRepo>();
            mockRepo.Setup(r => r.AddCrewMember(It.IsAny<Crew>())).ReturnsAsync((Crew member) =>
            {
                members.Add(member);
                return member;
            });


            return mockRepo;
        }

        public static Mock<ICrewRepo> UpdateCrewMember_Mock()
        {
            var member = new Crew()
            {
                MemberId = 9,
                MemberName = "Rajesh",
                IsActive = true
            };


            var mockRepo = new Mock<ICrewRepo>();
            mockRepo.Setup(r => r.UpdateCrewMember(It.IsAny<Crew>())).ReturnsAsync(member);
            return mockRepo;
        }

        public static Mock<ICrewRepo> DeleteCrew_Mock()
        {
            var member = new Crew()
            {
                MemberId = 9,
                MemberName = "Shirley",
                IsActive = true
            };
            var mockRepo = new Mock<ICrewRepo>();
            mockRepo.Setup(r => r.DeleteCrewMember(9)).ReturnsAsync(member);
            return mockRepo;
        }

        public static Mock<ICrewRepo> GetCrewMemberById_Mock()
        {
            var member =

                new Crew()
                {
                    MemberId = 9,
                    MemberName = "Shirley",
                    IsActive = true
                };


            var mockRepo = new Mock<ICrewRepo>();
            mockRepo.Setup(r => r.GetCrewMember(3)).ReturnsAsync(member);
            return mockRepo;
        }
    }
}
