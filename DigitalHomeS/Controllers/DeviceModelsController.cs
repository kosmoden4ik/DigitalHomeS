using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using DigitalHomeS.Models;
using Microsoft.Data.OData;

namespace DigitalHomeS.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using DigitalHomeS.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<DeviceModels>("DeviceModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DeviceModelsController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/DeviceModels
        public async Task<IHttpActionResult> GetDeviceModels(ODataQueryOptions<DeviceModels> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<DeviceModels>>(deviceModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/DeviceModels(5)
        public async Task<IHttpActionResult> GetDeviceModels([FromODataUri] int key, ODataQueryOptions<DeviceModels> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<DeviceModels>(deviceModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/DeviceModels(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<DeviceModels> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(deviceModels);

            // TODO: Save the patched entity.

            // return Updated(deviceModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/DeviceModels
        public async Task<IHttpActionResult> Post(DeviceModels deviceModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(deviceModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/DeviceModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<DeviceModels> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(deviceModels);

            // TODO: Save the patched entity.

            // return Updated(deviceModels);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/DeviceModels(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
