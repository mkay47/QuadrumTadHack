import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CasesRoutingModule} from './cases-routing.module';
import {CasesComponent} from './cases.component';

@NgModule({
    imports: [CommonModule, CasesRoutingModule],
    declarations: [CasesComponent]
})
export class CasesModule {}
