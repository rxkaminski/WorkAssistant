import { StatusSubMenu } from "./status-sub-menu";
import { ActivatedRoute } from "@angular/router";


export class Status {
  subMenu: subMenu;
  userId: number;

  constructor(activatedRoute: ActivatedRoute) {
    this.userId = activatedRoute.snapshot.params["userId"] | 0;
    this.subMenu = new StatusSubMenu(this.userId);
  }
}
