﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Models;

namespace InteraktivnaMapaEvenata.WebAPI.Controllers
{
    public class TagsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Tags
        public IQueryable<Tag> GetTags()
        {
            return db.Tags;
        }

        // GET: api/Tags/id
        [ResponseType(typeof(Tag))]
        public IHttpActionResult GetTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Tags/id
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTag(int id, Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tag.TagId)
            {
                return BadRequest();
            }

            db.Entry(tag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tags
        [ResponseType(typeof(Tag))]
        public IHttpActionResult PostTag(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tags.Add(tag);
            db.SaveChanges();

            return Ok(tag);
        }

        // DELETE: api/Tags/5
        [ResponseType(typeof(Tag))]
        public IHttpActionResult DeleteTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }

            db.Tags.Remove(tag);
            db.SaveChanges();

            return Ok(tag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagExists(int id)
        {
            return db.Tags.Count(e => e.TagId == id) > 0;
        }
    }
}