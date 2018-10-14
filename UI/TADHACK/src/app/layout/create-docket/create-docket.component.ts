import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';
import { CreateService } from '../../services/create-docket.module';
import { Case } from '../../model/create-docket.model';

@Component({
  selector: 'app-create-docket',
  templateUrl: './create-docket.component.html',
  styleUrls: ['./create-docket.component.scss']
})
export class CreateDocketComponent implements OnInit {
data: Case;
  constructor(private service:CreateService, private toastr: ToastrManager, private route: Router) { }

  ngOnInit() {
  }
  onSubmit(formData) {
    this.data = {
      
    }
    this.service.createCase().then({

    });
  }
}
