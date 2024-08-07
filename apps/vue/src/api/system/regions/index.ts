import { defHttp } from '/@/utils/http/axios';
import {
  Region,
  CreateRegion,
  UpdateRegion,
  GetAllRegionRequest,
  GetRegionPagedRequest,
} from './model';

export const create = (input: CreateRegion) => {
  return defHttp.post<Region>({
    url: '/api/system/region',
    data: input,
  });
};

export const update = (id: string, input: UpdateRegion) => {
  return defHttp.put<Region>({
    url: `/api/system/region/${id}`,
    data: input,
  });
};

export const deleteByCode = (code: string) => {
  return defHttp.delete<void>({
    url: `/api/system/region/${code}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Region>({
    url: `/api/system/region/${id}`,
  });
};

export const getAll = (input: GetAllRegionRequest) => {
  input.maxResultCount = 10000
  return defHttp.get<ListResultDto<Region>>({
    url: '/api/system/region',
    params: input,
  });
};

export const getList = (input: GetRegionPagedRequest) => {
  return defHttp.get<PagedResultDto<Region>>({
    url: '/api/system/region',
    params: input,
  });
};

