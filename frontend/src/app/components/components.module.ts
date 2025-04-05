import { NgModule } from "@angular/core";
import { NavBarComponent } from "./navBar/navBar.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

@NgModule({

  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavBarComponent
  ],
  declarations: [
    NavBarComponent
  ]
})

export class ComponentsModule {}
