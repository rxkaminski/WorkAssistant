interface IProject {
  Id: number;
  Number: string;
  Title: string;
  Description: string;
  Start: Date;
  End: Date;
  ProjectManagerId: number;
  ProjectManager: IApplicationUserShort;
  CreatedById: number;
  CreatedAt: Date;
  CreatedBy: IApplicationUserShort;
  ModifiedById: number;
  ModifiedAt: Date;
  ModifiedBy: IApplicationUserShort;
}
