using ServiceLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ServiceLayer
{
    public class TimeSheetLineService : BaseServiceLive, IRepository<MCT_Teknoloji_A_Ş__Time_Sheet_Line>
    {
        public MCT_Teknoloji_A_Ş__Time_Sheet_Line Delete(MCT_Teknoloji_A_Ş__Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetAll()
        {
           return Database.MCT_Teknoloji_A_Ş__Time_Sheet_Line.ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetByCode(string param)
        {
            return GetAll().Where(p => p.Time_Sheet_No_ == param).ToList();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Line GetById(string param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Line Insert(MCT_Teknoloji_A_Ş__Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Line Update(MCT_Teknoloji_A_Ş__Time_Sheet_Line param)
        {
            throw new NotImplementedException();
        }

        public MCT_Teknoloji_A_Ş__Time_Sheet_Line GetBySystemId(Guid param)
        {
            return GetAll().Where(p => p.C_systemId == param).SingleOrDefault();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetResourceTimeSheetLines(MCT_Teknoloji_A_Ş__Resource param)
        {
            List<MCT_Teknoloji_A_Ş__Time_Sheet_Header> ResourceTimeSheetHeader = new TimeSheetHeaderService().GetByCode(param.No_);
            List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> HeaderLines = new List<MCT_Teknoloji_A_Ş__Time_Sheet_Line>();
            foreach (MCT_Teknoloji_A_Ş__Time_Sheet_Header header in ResourceTimeSheetHeader)
            {
                List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> lines = GetByCode(header.No_);
                HeaderLines.AddRange(lines);
            }
            return HeaderLines;
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetOpenTimeSheetLines(MCT_Teknoloji_A_Ş__Resource param)
        {
            return GetResourceTimeSheetLines(param).Where(p => p.Status == 0).ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetSubmittedTimeSheets(MCT_Teknoloji_A_Ş__Resource param)
        {
            return GetResourceTimeSheetLines(param).Where(p => p.Status == 1).ToList();
        }
        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetRejectedTimeSheets(MCT_Teknoloji_A_Ş__Resource param)
        {
            return GetResourceTimeSheetLines(param).Where(p => p.Status == 2).ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetApprovedTimeSheets(MCT_Teknoloji_A_Ş__Resource param)
        {
            return GetResourceTimeSheetLines(param).Where(p => p.Status == 3).ToList();
        }

        public List<MCT_Teknoloji_A_Ş__Time_Sheet_Line> GetPostedTimeSheetLines(MCT_Teknoloji_A_Ş__Resource param)
        {
            return GetResourceTimeSheetLines(param).Where(p => p.Posted==1).ToList();
        }
    }
}
