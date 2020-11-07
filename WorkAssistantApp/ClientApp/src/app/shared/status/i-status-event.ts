interface IStatusEvent {
  Id: number;
  From: Date;
  To: Date;
  TypeId: number;
  Type: IStatusEventType;
  Description: string;
  ProjectId: number;
  Project: IProjectShort;
  CreatedById: number;
  CreatedAt: Date;
  CreatedBy: IApplicationUserShort;
  ModifiedById: number;
  ModifiedAt: Date;
  ModifiedBy: IApplicationUserShort;
}
