import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {VictimDashboardComponent} from './victim-dashboard.component';
const routes: Routes = [
    {
        path: '',
        component: VictimDashboardComponent,
        children: [
            { path: '', redirectTo: 'home', pathMatch: 'prefix' },
            { path: 'home', loadChildren: '../cases/cases.module#CasesModule' },
            { path: 'case', loadChildren: '../case/case.module#CaseModule' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class VictimDashboardRoutingModule {}
