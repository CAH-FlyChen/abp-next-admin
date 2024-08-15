
import { defHttp } from '/@/utils/http/axios';
import {
  Company,
  CreateCompany,
  UpdateCompany,
  GetCompanyPagedRequest,
} from './model';

export const create = (input: CreateCompany) => {
  return defHttp.post<Company>({
    url: '/api/system/company',
    data: input,
  });
};

export const update = (id: string, input: UpdateCompany) => {
  return defHttp.put<Company>({
    url: `/api/system/company/${id}`,
    data: input,
  });
};

export const deleteById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/system/company/${id}`,
  });
};

export const getById = (id: string) => {
  return defHttp.get<Company>({
    url: `/api/system/company/${id}`,
  });
};

export const getList = (input: GetCompanyPagedRequest) => {
  return defHttp.get<PagedResultDto<Company>>({
    url: '/api/system/company',
    params: input,
  });
};
