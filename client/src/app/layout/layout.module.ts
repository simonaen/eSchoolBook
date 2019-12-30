import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
   NbActionsModule,
   NbLayoutModule,
   NbMenuModule,
   NbSidebarModule
} from "@nebular/theme";
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ContentComponent } from './content/content.component';
import { RouterModule } from "@angular/router";
import { AppSettingsModule } from "../shared/app-settings-ui/app-settings.module";


@NgModule({
   declarations: [LayoutComponent, HeaderComponent, SidebarComponent, ContentComponent],
   exports: [
      LayoutComponent
   ],
   imports: [
      CommonModule,
      NbLayoutModule,
      NbSidebarModule,
      RouterModule,
      NbActionsModule,
      NbMenuModule,
      AppSettingsModule
   ]
})
export class LayoutModule {
}