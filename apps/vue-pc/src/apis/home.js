import httpInstance from '@/utils/http'


// 获取banner

export function getBannerAPI (params = {}) {
  // 默认为1 商品为2
  const { typeCode = 'Barnner',allowExpData=false } = params
  return httpInstance({
    url: '/api/system/ad',
    params: {
      typeCode
    }
  })
}

/**
 * @description: 获取新鲜好物
 * @param {*}
 * @return {*}
 */
export const findNewAPI = () => {
  return httpInstance({
    url: '/api/product/product/new'
  })
}

/**
 * @description: 获取人气推荐
 * @param {*}
 * @return {*}
 */
export const getHotAPI = () => {
  return httpInstance({
    url: '/api/product/product/hot'
  })
}

/**
 * @description: 获取分类信息带商品
 * @param {*}
 * @return {*}
 */
export const getGoodsAPI = () => {
  return httpInstance({
    url: '/api/product/category/treedata',
    params:{
      isResultIncludeProduct:true
    }
  })
}