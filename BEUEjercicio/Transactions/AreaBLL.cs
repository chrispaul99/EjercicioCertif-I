using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AreaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio
        /*public static void Create(Area a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Area.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Area Get(int? id)
        {
            Entities db = new Entities();
            return db.Area.Find(id);
        }

        public static void Update(Area area)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Area.Attach(area);
                        db.Entry(area).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Area area = db.Area.Find(id);
                        db.Entry(area).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private static List<Area> GetAreaa(string criterio)
        {
            Entities db = new Entities();
            return db.Area.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }

        private static Area GetArea(string nombre)
        {
            Entities db = new Entities();
            return db.Area.FirstOrDefault(x => x.nombre == nombre);
        }*/
        public static List<Area> List()
        {
            Entities db = new Entities();
            return db.Area.ToList();
        }

    }
}
