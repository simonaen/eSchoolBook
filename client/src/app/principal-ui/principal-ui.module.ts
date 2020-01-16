import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {PrincipalService} from './shared/services/principal.service';
import {NbDialogModule} from "@nebular/theme";

const principalUiModuleRoutes: Routes = [
    {
       path: '',
       redirectTo: 'statistics',
       pathMatch: 'full'
    },
    {
        path: 'statistics',
        loadChildren: () => import('./statistics/principal-statistics.module').then(m => m.PrincipalStatisticsModule)
     },
    {
       path: 'students',
       loadChildren: () => import('./students-data/students-data.module').then(m => m.StudentsDataModule)
    },
    {
       path: 'teachers',
       loadChildren: () => import('./teachers-data/teachers-data.module').then(m => m.TeachersDataModule)
    },
    {
        path: 'teacher',
        loadChildren: () => import('../teacher-ui/teacher-ui.module').then(m => m.TeacherUiModule)
    },
    {
      path: 'parents',
      loadChildren: () => import('./parents-data/parents-data.module').then(m => m.ParentsDataModule)
   }
 ];
 
 @NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(principalUiModuleRoutes),
        NbDialogModule.forChild(),
    ],
    providers: [PrincipalService]
 })
 export class PrincipalUiModule {
 }
 