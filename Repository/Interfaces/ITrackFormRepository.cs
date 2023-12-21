using BussinessObject;
using BussinessObject.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITrackFormRepository
    {
        public List<trackForm> GetTracksFromList();
        public trackForm GetTrackFormById(Guid id);
        public trackForm AddTrackForm(trackForm trackForm);
        public trackForm updateTrackform(Guid id, trackFormUpdateInfo trackFormUpdateInfo);
        public bool DeleteTrackForm(trackForm feedback);
    }
}
