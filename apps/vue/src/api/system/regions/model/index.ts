import { number } from "vue-types";

export interface Region{
  code: string;
  name: string;
  parentCode: string;
  regionTypeCode: number;
  children?: Region[];
}


export interface CreateOrUpdateRegion {
  name: string;
  path: string;
  component: string;
  displayName: string;
  description?: string;
  redirect?: string;
  isPublic: boolean;
  meta: { [key: string]: any };
}

export interface CreateRegion extends CreateOrUpdateRegion {
  layoutId: string;
  parentId?: string;
}

export type UpdateRegion = CreateOrUpdateRegion;

export interface GetAllRegionRequest extends SortedResultRequest {
  filter?: string;
  sorting?: string;
  parentCode?: string;
  framework?: string;
  maxResultCount?:number;
}

export interface GetRegionPagedRequest extends PagedAndSortedResultRequestDto {
  code?: string;
  name?: string;
  parentCode?: string;
  regionTypeCode?: number;
}

