using backend.Helper;
using backend.Models;
using System.Data.SqlClient;

namespace backend.Repository
{
    public class TicketRepository
    {
        public List<TicketModel> getTicket()
        {
            string query = "Select * FROM tblTicket";
            List<TicketModel> ticket = Connection.QueryObjectList<TicketModel>(query);
            return ticket;
        }

        public int CreateTicket(TicketRequrst requrst)
        {
            string strSQL = string.Format("INSERT INTO tblTicket(ticket_id, ticket_title, ticket_description, ticket_contact, ticket_status, ticket_time_create, ticket_time_update) " +
                "VALUES(@ticket_id, @ticket_title, @ticket_description, @ticket_contact, @ticket_status, @ticket_time_create, @ticket_time_update)");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ticket_id", CreateId()));
            parameters.Add(new SqlParameter("@ticket_title", requrst.ticket_title));
            parameters.Add(new SqlParameter("@ticket_description", requrst.ticket_description));
            parameters.Add(new SqlParameter("@ticket_contact", requrst.ticket_contact));
            parameters.Add(new SqlParameter("@ticket_status", requrst.ticket_status));
            parameters.Add(new SqlParameter("@ticket_time_create", GetTimestamp(DateTime.Now)));
            parameters.Add(new SqlParameter("@ticket_time_update", GetTimestamp(DateTime.Now)));
            return Connection.ExecuteSQLCommand(strSQL, parameters);
        }

        public int UpdateTicket(TicketRequrst requrst, string ticket_Id)
        {
            string strSQL = string.Format("UPDATE tblTicket SET ticket_title = @ticket_title, ticket_description = @ticket_description, " +
                "ticket_contact = @ticket_contact, ticket_status = @ticket_status, ticket_time_update = @ticket_time_update WHERE ticket_id = {0}", ticket_Id);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ticket_title", requrst.ticket_title));
            parameters.Add(new SqlParameter("@ticket_description", requrst.ticket_description));
            parameters.Add(new SqlParameter("@ticket_contact", requrst.ticket_contact));
            parameters.Add(new SqlParameter("@ticket_status", requrst.ticket_status));
            parameters.Add(new SqlParameter("@ticket_time_update", GetTimestamp(DateTime.Now)));
            return Connection.ExecuteSQLCommand(strSQL, parameters);
        }

        public string CreateId()
        {
            string sql = string.Format("SELECT TOP 1 * FROM tblTicket ORDER BY CAST(ticket_id AS INT) DESC");
            List<TicketModel> dataRow = Connection.QueryObjectList<TicketModel>(sql);
            if (dataRow.Count == 0)
            {
                return "1";
            }

            int newId = Convert.ToInt32(dataRow[0].ticket_id);
            newId++;
            return newId.ToString();
        }

        public string GetTimestamp(DateTime value)
        {
            var input = value.ToString("yyyyMMddHHmmssffff");
            return convertDate(input);
        }

        public string convertDate(string input)
        {
            DateTime result;
            if (DateTime.TryParseExact(input, "yyyyMMddHHmmssffff", null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result.ToString();
            }
            return null;
        }
    }
}
