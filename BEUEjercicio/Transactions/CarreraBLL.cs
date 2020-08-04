using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class CarreraBLL
    {
        public static void Create(Carrera c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Carrera.Add(c);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static Carrera Get(int? id)
        {
            Entities db = new Entities();
            return db.Carrera.Find(id);
        }

        public static void Update(Carrera carrera)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Carrera.Attach(carrera);
                        db.Entry(carrera).State = System.Data.Entity.EntityState.Modified;
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
                        Carrera carrera = db.Carrera.Find(id);
                        db.Entry(carrera).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Carrera> List()
        {
            Entities db = new Entities();
            return db.Carrera.ToList();
        }


        private static List<Carrera> GetCarreras(string criterio)
        {
            Entities db = new Entities();
            return db.Carrera.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }
        public static List<Carrera> List(string criterio)
        {
            Entities db = new Entities();
            return db.Carrera.Where(x => x.nombre.Contains(criterio)).ToList();
        }
        private static Carrera GetCarrera(string nombre)
        {
            Entities db = new Entities();
            return db.Carrera.FirstOrDefault(x => x.nombre == nombre);
        }
    }
}
