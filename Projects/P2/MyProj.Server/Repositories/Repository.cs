using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProj.Shared.Data;
using System.Net.Http;

namespace MyProj.Server.Repositories
{
    public class Repository
    {
        private ModelContext _dbContext;
        public Repository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllSchools()
        {
            return await Task.Run(() => _dbContext.Professors.GroupBy(p => p.College).Select(g => g.Key));
        }
        public async Task<IEnumerable<Professor>> Teachers(string school)
        => await Task.Run(() => _dbContext.Professors.Where(p => p.College.Contains(school))
            .ToList().OrderByDescending(t => t.TotalRate));
        public async Task<IEnumerable<string>> Lessonss(string school)
        => await Task.Run(() => _dbContext.Booklets.ToList().Where(p => p.College.Contains(school))
            .ToList().GroupBy(j => j.Lesson).Select(p => p.Key));

        internal async Task AddBooklet(MultipartFormDataContent file)
        {
            var path = Path.Combine(@"C:\git\AP98992\Projects\P2\MyProject\wwwroot\books", "books", file.First().ToString());
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        internal async Task<IEnumerable<Booklet>> Booklets(string lesson)
        => await Task.Run(() => _dbContext.Booklets.ToList().Where(b => b.Lesson == lesson));
        public Professor FindTeacher(string name, string school)
        => _dbContext.Professors
        .FirstOrDefault(t=> t.Name.Contains(name) && t.College.Contains(school));

        internal void RateTeacher(long id, Rate rate)
        {
            var entity = _dbContext.Professors.First(t => t.Id == id);
            long i = entity.VoteNum;
            entity.BehaviorRate = (int)(((entity.BehaviorRate*i) + (rate.Behavior*100/4))/(i+1));
            entity.TeachingRate = (int)(((entity.TeachingRate*i) + (rate.Teaching*100/4))/(i+1));
            entity.ScoreRate = (int)(((entity.ScoreRate*i) + (rate.Score*100/3))/(i+1));
            entity.ExamRate = (int)(((entity.ExamRate*i) + (rate.Exam*100/3))/(i+1));
            entity.AttendanceRate = (int)(((entity.AttendanceRate*i) + (rate.Attendance*100/3))/(i+1));
            entity.VoteNum++;

            _dbContext.Professors.Update(entity);
            _dbContext.SaveChanges();
        }

        internal async Task RemoveComment(long id)
        {
            var entity = _dbContext.Comments.First(t => t.Id == id);
            await Task.Run(() => _dbContext.Comments.Remove(entity));
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Comment>> LoadComments(long id)
        => await Task.Run(() => _dbContext.Comments.Where(c => c.TeacherId == id));
        public async Task<Comment> AddComment(Comment comment)
        {
            int l = _dbContext.Comments.Count();
            comment.Id = l == 0? 0: _dbContext.Comments.Max(c => c.Id) + 1;
             await Task.Run(() =>_dbContext.Comments.Add(comment));
            _dbContext.SaveChanges();
            return comment;
        }
    }
}