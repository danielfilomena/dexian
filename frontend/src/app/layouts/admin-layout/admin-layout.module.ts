import { CommonModule } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import { AdminLayoutRoutes } from "./admin-layout.routing";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { EscolaComponent } from "../../pages/escola/escola.component";
import { EscolaFormComponent } from "../../pages/escola/escola-form/escola-form.component";
import { AlunoComponent } from "../../pages/aluno/aluno.component";
import { AlunoFormComponent } from "../../pages/aluno/aluno-form/aluno-form.component";
import { NgxMaskDirective, NgxMaskPipe } from "ngx-mask";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    NgxMaskDirective,
    NgxMaskPipe
  ],
  declarations: [
    DashboardComponent,
    EscolaComponent,
    EscolaFormComponent,
    AlunoComponent,
    AlunoFormComponent
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})

export class AdminLayoutModule {}
