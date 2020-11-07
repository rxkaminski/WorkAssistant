export class ProjectsSubMenu implements subMenu {
  links: subMenuLinks[];

  constructor() {
    this.links = [
      { ahref: "/projects/view", linkName: "Projects", isActive: false },
    ];
  }
}
