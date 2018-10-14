import { Component, OnInit } from '@angular/core';
import {CasesService} from '../../../services/cases.service';

@Component({
  selector: 'app-case',
  templateUrl: './case.component.html',
  styleUrls: ['./case.component.scss']
})
export class CaseComponent implements OnInit {
    case: object;

  constructor(private casesService: CasesService) { }

  ngOnInit() {
      this.casesService.getCase(1).subscribe((data) => {
          this.case = data;
      });
  }

    onClick(value) {
      alert('Saved');
    }

    saveChanges() {

    }
}
