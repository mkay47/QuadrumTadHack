import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-cassde',
  templateUrl: './case.component.html',
  styleUrls: ['./case.component.scss']
})
export class CaseComponent implements OnInit {


    caseId: string;
  constructor(private route: ActivatedRoute) {


  }

  ngOnInit() {

  }

}
