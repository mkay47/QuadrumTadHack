import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CaseComponent} from './case.component';
import {CaseRoutingModule} from './case-routing.module';

@NgModule({
    imports: [CommonModule, CaseRoutingModule],
    declarations: [CaseComponent]
})
export class CaseModule { }
