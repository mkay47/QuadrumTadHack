import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-create-docket',
  templateUrl: './create-docket.component.html',
  styleUrls: ['./create-docket.component.scss']
})
export class CreateDocketComponent implements OnInit {

  constructor(private toastr: ToastrManager, private route: Router) { }

  ngOnInit() {
  }
  onSubmit(formData) {
    this.toastr.successToastr(`Successfully Added ${formData.value.fullName} ${formData.value.idNumber}`, 'Success!');
  }
}
