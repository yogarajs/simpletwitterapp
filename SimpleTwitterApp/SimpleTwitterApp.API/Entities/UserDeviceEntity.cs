namespace SimpleTwitterApp.API.Entities
{
    public class UserDeviceEntity
    {
        public int UserDeviceId { get; set; }

        public int UserId { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceName { get; set; }
    }
}