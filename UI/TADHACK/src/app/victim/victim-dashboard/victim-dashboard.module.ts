import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {VictimDashboardRoutingModule} from './victim-dashboard-routing.module';
import {VictimDashboardComponent} from './victim-dashboard.component';
@NgModule({
    imports: [CommonModule, VictimDashboardRoutingModule],
    declarations: [VictimDashboardComponent]
})
export class VictimDashboardModule {}
