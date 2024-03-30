namespace backend.Models.Response
{
    public class ResponseModel
    {
        public ResponseModel()
        {

        }

        public ResponseModel(object? _Data = null, StateType.Type type = StateType.Type.SUCCESS)
        {
            Data = _Data;
            switch (type)
            {
                case StateType.Type.SUCCESS:
                    message = "สำเร็จ";
                    break;
                case StateType.Type.NOTFOUND_DATA:
                    message = "ไม่พบข้อมูล";
                    break;
                case StateType.Type.SAVE_SUCCESS:
                    message = "บันทึกข้อมูลสำเร็จ";
                    break;
                case StateType.Type.SAVE_FAILER:
                    message = "บันทึกข้อมูลไม่สำเร็จ";
                    break;
                default:
                    break;
            }
        }

        public string? message { get; set; }
        public object? Data { get; set; }
    }
}
