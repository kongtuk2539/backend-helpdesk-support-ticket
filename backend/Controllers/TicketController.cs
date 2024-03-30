using backend.Models;
using backend.Models.Response;
using backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        TicketRepository tr = new TicketRepository();


        [HttpGet]
        public ActionResult<ResponseModel> GetTicket()
        {
            List<TicketModel> result = tr.getTicket();

            if (result.Count > 0)
            {
                return new ResponseModel(result, StateType.Type.SUCCESS);
            }
            return new ResponseModel(null, StateType.Type.SAVE_FAILER);
        }

        [HttpPost]
        public ActionResult<ResponseModel> CreateTicket(TicketRequrst requrst) 
        {
            int result = tr.CreateTicket(requrst);
            if (result > 0)
            {
                return new ResponseModel(null, StateType.Type.SAVE_SUCCESS);
            }
            return new ResponseModel(null, StateType.Type.SAVE_FAILER);
        }

        [HttpPut("{id}")]
        public ActionResult<ResponseModel> UpdateTicket([FromBody] TicketRequrst requrst, string id)
        {
            int status = tr.UpdateTicket(requrst, id);
            if (status > 0)
            {
                return new ResponseModel(null, StateType.Type.SAVE_SUCCESS);
            }
            return new ResponseModel(null, StateType.Type.SAVE_FAILER);
        }
    }
}
