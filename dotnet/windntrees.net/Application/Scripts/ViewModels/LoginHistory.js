function LoginHistory(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UserID = data.UserID;
    instance.LoginTime = data.LoginTime;
    instance.IP = data.IP;
}