interface IStatusCurrent {
  Id: number;
  UserId: number;
  StatusDescription: string;
  StatusAvailableUse: boolean;
  StatusAvailableFrom: Date;
  StatusAvailableTo: Date;
  StartHourOnMondayId: number;
  StartHourOnTuesdayId: number;
  StartHourOnWednesdayId: number;
  StartHourOnThursdayId: number;
  StartHourOnFridayId: number;
  Project: IProjectShort;
  ModifiedById: number;
  ModifiedAt: Date;
  ModifiedBy: IApplicationUserShort;
}
