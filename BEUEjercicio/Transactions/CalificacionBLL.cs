using System;
using System.Collections.Generic;
using System.Linq;

namespace BEUEjercicio.Transactions
{
    public class CalificacionBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Calificacion m,bool ban)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Config(m,ban);
                        db.Calificacion.Add(m);
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
        private static void Config(Calificacion a, bool byForeach)
        {
            a.fecha = DateTime.Now;
            a.valor = 0;
            if (byForeach)
            {
                foreach (var ap in a.Aporte)
                {
                    ap.puntaje = (ap.valor * ap.ponderado) / 20;
                    a.valor += ap.puntaje;
                }
                return;
            }
            a.Aporte.ToList().ForEach(ap => ap.puntaje =(ap.valor * ap.ponderado) / 20);
            a.valor = a.Aporte.Sum(ap => ap.puntaje);
        }
        public static Calificacion Get(int? id)
        {
            Entities db = new Entities();
            return db.Calificacion.Find(id);
            
        }

        public static void Update(Calificacion Calificacion)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Calificacion.Attach(Calificacion);
                        db.Entry(Calificacion).State = System.Data.Entity.EntityState.Modified;
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
                        Calificacion Calificacion = db.Calificacion.Find(id);
                        db.Entry(Calificacion).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<Calificacion> List()
        {
            Entities db = new Entities();
            return db.Calificacion.ToList();

        }
        public static List<Calificacion> List(int id)
        {
            Entities db = new Entities();
            return db.Calificacion.Where(x => x.idmatricula == id).ToList();
        }
    }
}
