using BEUEjercicio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class MatriculaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Matricula m)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Matricula.Add(m);
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
        private static void Config(Matricula a, Materia mt)
        {
            a.fecha = DateTime.Now;
            a.estado = "1"; //Creada
            if (a.tipo.Equals("P"))
            {
                a.costo = 0;
            }
            else if (a.tipo.Equals("S"))
            {
                a.costo = (decimal)(12.25 * mt.creditos);
            }
            else
            {
                a.costo = (decimal)(24.50 * mt.creditos);
            }
        }
        public static Matricula Get(int? id)
        {
            Entities db = new Entities();
            
            return TransforEnum(db.Matricula.Find(id));
        }

        public static void Update(Matricula matricula)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Matricula.Attach(matricula);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Modified;
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
                        Matricula matricula = db.Matricula.Find(id);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Deleted;
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
        public static List<String> ListEnum(String enumerado)
        {
            List<String> listado = new List<string>();
            switch (enumerado)
            {
                case "estado": return listado = Enum.GetNames(typeof(Estados)).ToList();
                case "tipo": return listado = Enum.GetNames(typeof(Tipo)).ToList();
                default: return null;
            }
        }
        public static  Matricula TransforEnumCreate(Matricula m)
        {
            int i = 0;
            bool ban = true;
            Type tip = typeof(Tipo);
            string valor = m.tipo;
            for (int index = 0; index < 2; index++)
            {
                foreach (string tipo in Enum.GetNames(tip))
                {
                    if (valor == tipo)
                    {
                        valor = m.estado;
                        if (ban)
                            m.tipo = Enum.GetValues(typeof(Tipo)).Cast<int>().ToList()[i].ToString();
                        else
                            m.estado = Enum.GetValues(typeof(Tipo)).Cast<int>().ToList()[i].ToString();
                        ban = false;
                        i = 0;
                        break;
                    }
                    i++;
                }
                tip = typeof(Estados);
            }
            return m;
        }
        public static Matricula TransforEnum(Matricula m)
        {
            int i = 0;
            bool ban = true;
            Type tip = typeof(Tipo);
            string valor = m.tipo;
            for(int index = 0; index < 2; index++)
            {
                foreach (int item in Enum.GetValues(tip))
                {
                    if (valor == (item).ToString())
                    {
                        valor = m.estado;
                        if(ban)
                            m.tipo = Enum.GetNames(typeof(Tipo)).Cast<String>().ToList()[i].ToString();
                        else
                            m.estado = Enum.GetNames(typeof(Estados)).Cast<String>().ToList()[i].ToString();
                        ban = false;
                        i = 0;
                        break;
                    }
                    i++;
                }
                tip = typeof(Estados);
            }
            return m;
        }
        public static List<Matricula> List()
        {
            Entities db = new Entities();
            foreach(var i in db.Matricula)
            {
                TransforEnum(i);
            }
            return db.Matricula.ToList();


            //Los metodos del EntityFramework se denomina Linq, 
            //y la evluacion de condiciones lambda
        }
        public static List<Matricula> List(int id)
        {
            Entities db = new Entities();
            return db.Matricula.Where(x => x.Alumno.idalumno == id).ToList();
        }
        /*
        private static List<Matricula> GetMatriculas(String criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities db = new Entities();
            return db.Matricula.Where(x => x.Alumno.nombres.ToLower().Contains(criterio)).ToList();
        }

        private static Matricula GetMatricula(string cedula)
        {
            Entities db = new Entities();
            return db.Matricula.FirstOrDefault(x => x.Alumno.cedula == cedula);
        }
        */
    }
}
