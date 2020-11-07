import { StatusUrl } from "./status-url";

export class StatusSubMenu implements subMenu {
  links: subMenuLinks[];

  constructor(userId: number) {
    this.links = [
      { ahref: StatusUrl.create("", userId, "/status/current"), linkName: "Current", isActive: false },
      { ahref: StatusUrl.create("", userId,  "/status/events"), linkName: "Events", isActive: false },
      { ahref: StatusUrl.create("", userId,  "/status/projects"), linkName: "Projects", isActive: false },
      { ahref: StatusUrl.create("", userId,  "/status/history"), linkName: "History", isActive: false },
    ];

  }
}
