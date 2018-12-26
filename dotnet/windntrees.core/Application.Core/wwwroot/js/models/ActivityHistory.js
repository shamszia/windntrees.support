function ActivityHistory(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.UserId = data.UserId;
    instance.ActivityTime = data.ActivityTime;
    instance.Activity = data.Activity;
    instance.Request = data.Request;
    instance.Ipaddress = data.Ipaddress;

}