export class StatusUrl {
  static create(prefix: string, userId: number, suffix: string): string {
    var userIdUrl = "";

    if (userId != undefined && userId > 0)
      userIdUrl = "/user/" + userId;

    return prefix + userIdUrl + suffix;
  }
}
