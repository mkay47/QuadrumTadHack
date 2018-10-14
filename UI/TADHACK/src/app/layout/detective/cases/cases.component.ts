import { Component, OnInit } from '@angular/core';
import {CasesService} from '../../../services/cases.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-cases',
  templateUrl: './cases.component.html',
  styleUrls: ['./cases.component.scss']
})
export class CasesComponent implements OnInit {
    cases: Array<object> = [];

  constructor(private casesService: CasesService, private route: Router) { }

  ngOnInit() {
      this.casesService.getCases().subscribe((data: Array<object>) => {
        this.cases = data;
      });
      console.log(this.cases);
  }

    openCase() {
        this.route.navigate(['case']);
    }
}
