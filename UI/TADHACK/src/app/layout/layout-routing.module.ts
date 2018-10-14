import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';
const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', redirectTo: 'cases', pathMatch: 'prefix' },
            { path: 'cases', loadChildren: './detective/cases/cases.module#CasesModule' },
            { path: 'case', loadChildren: './detective/case/case.module#CaseModule' }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule {}
