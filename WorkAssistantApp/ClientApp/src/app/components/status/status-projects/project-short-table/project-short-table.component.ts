import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-project-short-table',
  templateUrl: './project-short-table.component.html',
  styleUrls: ['./project-short-table.component.css']
})
export class ProjectShortTableComponent implements OnInit {
  @Input() tableUrl: string;
  tableData: IProjectShort[];

  displayedColumns: string[] = ['number', 'title'];

  constructor(private httpClient: HttpClient) {

  }

  ngOnInit(): void {
    this.httpClient.get<IProjectShort[]>(this.tableUrl).subscribe(result => {
      this.tableData = result;
    }, error => console.log(error))
  }
}
