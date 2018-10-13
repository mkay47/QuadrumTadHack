import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

import { CreateDocketRoutingModule } from './create-docket-routing.module';
import { CreateDocketComponent } from './create-docket.component';

@NgModule({
    imports: [CommonModule, CreateDocketRoutingModule, FormsModule],
    declarations: [CreateDocketComponent]
})
export class CreateDocketModule {}
