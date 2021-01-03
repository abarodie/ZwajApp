using System.ComponentModel.DataAnnotations;

namespace ZawajApp.api.Dtos
{
    public class UserForRegisterDto
    {   
        [Required]
        public string Username { get; set; }
        [StringLength(8,MinimumLength=4,ErrorMessage="أن لا تقل كلمة السر عن 4 حروف ولا  تزيد عن ثمانية")]
        public string Password { get; set; }
    }
}