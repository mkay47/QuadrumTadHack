import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CaseRoutingModule} from './case-routing.module';
import {CaseComponent} from './case.component';


@NgModule({
    imports: [CommonModule, CaseRoutingModule],
    declarations: [CaseComponent]
})
export class CaseModule {}
