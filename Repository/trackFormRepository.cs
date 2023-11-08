﻿using BussinessObject;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class trackFormRepository :ITrackFormRepository
    {
        private readonly trackFormDAO dao;

        public trackFormRepository(MyDbContext dbContext)
        {
            dao = new trackFormDAO(dbContext);
        }

        public trackForm AddTrackForm(trackForm trackForm) =>dao.AddTrackForm(trackForm);

        public bool DeleteTrackForm(trackForm feedback) => dao.DeleteTrackForm(feedback);

        public trackForm GetTrackFormById(Guid id)=>dao.GetTrackFormById(id);

        public List<trackForm> GetTracksFromList()=>dao.GetTracksFromList();

        public trackForm updateTrackform(trackForm feedback)=>dao.updateTrackform(feedback);
    }
}
