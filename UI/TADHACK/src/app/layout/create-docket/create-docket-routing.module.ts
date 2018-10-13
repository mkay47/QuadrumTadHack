import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateDocketComponent } from './create-docket.component';

const routes: Routes = [
    {
        path: '',
        component: CreateDocketComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CreateDocketRoutingModule {}
