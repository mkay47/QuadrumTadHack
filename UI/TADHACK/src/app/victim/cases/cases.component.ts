import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';

@Component({
  selector: 'app-cases',
  templateUrl: './cases.component.html',
  styleUrls: ['./cases.component.scss']
})
export class CasesComponent implements OnInit {

    cases = [
        {caseId: 'SSD', caseName: 'Theft case', detectiveName: 'Sizwe Mkhululi', status: 'In Progress', createdAt: '2018-10-01'},
        {caseId: 'sdsds', caseName: 'Robbery', detectiveName: 'Nokuthula Mkhonza', status: 'Closed', createdAt: '2017-10-02'},
        {caseId: '154', caseName: 'House break in', detectiveName: 'John Smith', status: 'Pending', createdAt: '2018-10-13'}
    ];

  constructor(private route: Router) { }

  ngOnInit() {
  }

    handleCaseClick(index) {
        this.route.navigate(['/victim/case', {queryParams: {caseId: this.cases[index].caseId}}]);
    }
}
