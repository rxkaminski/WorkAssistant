import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sub-menu',
  templateUrl: './sub-menu.component.html',
  styleUrls: ['./sub-menu.component.css']
})
export class SubMenuComponent implements OnInit {
  @Input() subMenu: subMenu;


  constructor(private activatedRoute: ActivatedRoute, private router: Router) {

  }

  ngOnInit() {
    var path = "/" + this.activatedRoute.snapshot.routeConfig.path;

    this.subMenu.links.forEach(m => {
      if (path == m.ahref)
        m.isActive = true;
    });
  }

}
