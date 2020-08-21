﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace WebApiEscolastico.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CalificacionController : ApiController
    {
        public IHttpActionResult Post(Calificacion calificacion)
        {
            try
            {
                CalificacionBLL.Create(calificacion,true);
                return Content(HttpStatusCode.Created, "Calificacion creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}