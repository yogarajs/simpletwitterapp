namespace SimpleTwitterApp.API.Entities
{
    public class UserDeviceEntity
    {
        public long UserDeviceId { get; set; }

        public long UserId { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceName { get; set; }
    }
}