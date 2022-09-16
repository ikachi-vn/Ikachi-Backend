using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OfficeOpenXml;



namespace ClassLibrary
{
    public static class errorLog
    {
        private static ILog log = log4net.LogManager.GetLogger("API Logs");

        public static void logMessage(string FunctionName, DbEntityValidationException e)
        {
            log.Error(FunctionName, e);
            foreach (var eve in e.EntityValidationErrors)
            {

                log.Error(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                foreach (var ve in eve.ValidationErrors)
                {
                    log.Debug(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                }

            }
        }

        public static void logChanges<T1, T2>(T1 self, T2 to)
        {
            

            if (self != null && to != null)
            {
                Type type1 = typeof(T1);
                Type type2 = typeof(T2);
                string[] ignore = { "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" };
                List<string> ignoreList = new List<string>(ignore);

                ModelChangeLog changeLog = new ModelChangeLog();
                changeLog.Model = type1.Name;
                changeLog.Changes = new List<TrackChanged>();

                foreach (System.Reflection.PropertyInfo pi in type2.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name) && type1.GetProperty(pi.Name) != null && type2.GetProperty(pi.Name) != null)
                    {
                        object selfValue = type1.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type2.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            changeLog.Changes.Add(new TrackChanged() { Property = pi.Name, OldValue = (selfValue==null ? "" : selfValue.ToString()), NewValue = (toValue == null ? "" : toValue.ToString())  });
                            
                            //return false;
                        }
                    }
                }
                //string changed = string.Join(",", changedProperties.ToArray());

                if (changeLog.Changes.Count > 0)
                {
                    string changed = Newtonsoft.Json.JsonConvert.SerializeObject(changeLog);
                    log.Info(changed);
                }

                
                //return true;
            }
            
        }
        public static void bindChanges<T2>(dynamic from, T2 to)
        {


            if (from != null && to != null)
            {
                
                Type type2 = typeof(T2);
                string[] ignore = { "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" };
                List<string> ignoreList = new List<string>(ignore);

                ModelChangeLog changeLog = new ModelChangeLog();
                changeLog.Model = type2.Name;
                changeLog.Changes = new List<TrackChanged>();

                foreach (System.Reflection.PropertyInfo pi in type2.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = from[pi.Name];
                        object toValue = type2.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            type2.GetProperty(pi.Name).SetValue(to, selfValue);
                            changeLog.Changes.Add(new TrackChanged() { Property = pi.Name, NewValue = (selfValue == null ? "" : selfValue.ToString()), OldValue = (toValue == null ? "" : toValue.ToString()) });

                            //return false;
                        }
                    }
                }
                //string changed = string.Join(",", changedProperties.ToArray());

                if (changeLog.Changes.Count > 0)
                {
                    string changed = Newtonsoft.Json.JsonConvert.SerializeObject(changeLog);
                    log.Info(changed);
                }


                //return true;
            }

        }
    }
}
